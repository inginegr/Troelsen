using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Reflection;
using Security;
using ServiceLibrary.Various;
using System.Windows.Controls;
using SocialNetworks.Telegramm;
using SocialNetworks.VK;
using System.Net.Http;
using SocialNetworks.TGObjects;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace SCN_App
{
    public class HandleClass
    {
        FileService fServ = new FileService();

        CommonService comServ = new CommonService();

        SLCryptography localCrypto = new SLCryptography();

        //VKComunicate vkc = null;
        TGCommunicate tgc = null;



        // Methods of loaded library
        List<MethodInfo> Methods = new List<MethodInfo>();


        /// <summary>
        /// Save encrypted token
        /// </summary>
        /// <param name="stringToSave">Data to encrypt</param>
        public void SaveKeySafely(string stringToSave)
        {
            try
            {
                byte[] encryptedData = localCrypto.EncryptData(stringToSave);

                string s = comServ.MassivToString(encryptedData, " ");

                fServ.LogData("tkn.txt", s);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Load saved token
        /// </summary>
        /// <returns></returns>
        public string LoadToken()
        {
            string returnString = null;
            try
            {
                string tkn = fServ.ReadFileToString("tkn.txt");

                byte[] bt = comServ.StringToMassive<byte>(tkn, " ", typeof(byte)).ToArray();

                returnString = localCrypto.DecryptData(bt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return returnString;
        }

        /// <summary>
        /// Load vk library and set methods of combobox list
        /// </summary>
        /// <param name="control"></param>
        public void LoadVkLibrary(Control control)
        {
            //vkc = new VKComunicate(LoadToken());
            tgc = new TGCommunicate(LoadToken());

            LoadCommandList(control, new TGCommunicate(LoadToken()));
        }

        /// <summary>
        /// Loads methods to combobox list
        /// </summary>
        /// <param name="control"></param>
        /// <param name="vk"></param>
        private void LoadCommandList<T>(Control control, T server)
        {
            try
            {
                ComboBox cbx = (ComboBox)control;

                List<string> commandList = new List<string>();

                Methods = server.GetType().GetMethods().ToList();

                foreach (MethodInfo m in Methods)
                {
                    commandList.Add(m.Name.ToString());
                }

                cbx.ItemsSource = commandList;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Sends selected command to server
        /// </summary>
        /// <param name="control"></param>
        public async void SendCommand(Control control)
        {
            try
            {
                ComboBox cbx = (ComboBox)control;

                MethodInfo mi = Methods.Find(e => e.Name == cbx.SelectedItem.ToString());

                await Task.Run(() => mi.Invoke(tgc, null));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void GetQueueTGUpdatesCollection(TextBox tbx)
        {
            try
            {
                do
                {
                    Thread.Sleep(1000);

                    MethodInfo mi = Methods.Find(e => e.Name == "get_HandleQueueMessages");
                    Queue<TGUpdate> messageList = (Queue<TGUpdate>)mi.Invoke(tgc, null);

                    string s = String.Empty;

                    bool flg = false;
                    while (messageList.Count != 0)
                    {
                        flg = true;
                        s += messageList.Dequeue().ToString();
                    }
                    if (flg)
                    {
                        tbx.Dispatcher.Invoke(DispatcherPriority.Background, new Action(() =>
                        {
                            tbx.Text = s;
                        }));
                    }
                } while (true);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Display text insisde textbox
        /// </summary>
        /// <param name="list">List to display</param>
        /// <param name="control">Textbox for display</param>
        public async void FillData(Control control)
        {
            await Task.Run(() => GetQueueTGUpdatesCollection((TextBox)control));

        }
    }
}
