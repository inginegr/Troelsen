using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Security;
using ServiceLibrary;
using System.Windows.Controls;
using VKLibrary;
using SocialNetworks.VKObjects;


namespace SCN_App
{
    class HandleClass
    {
        FileService fServ = new FileService();

        CommonService comServ = new CommonService();

        SLCryptography localCrypto = new SLCryptography();

        VKComunicate vkc = null;

        // Methods of loaded library
        List<MethodInfo> vkMethods = new List<MethodInfo>();


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

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Load saved token
        /// </summary>
        /// <returns></returns>
        private string LoadToken()
        {
            string returnString = null;
            try
            {
                string tkn = fServ.ReadFileToString("tkn.txt");

                byte[] bt = comServ.StringToMassive<byte>(tkn, " ", typeof(byte)).ToArray();

                returnString = localCrypto.DecryptData(bt);
            }catch(Exception ex)
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
            vkc = new VKComunicate(LoadToken());

            LoadCommandList(control, vkc);
        }

        /// <summary>
        /// Loads methods to combobox list
        /// </summary>
        /// <param name="control"></param>
        /// <param name="vk"></param>
        private void LoadCommandList(Control control, VKComunicate vk)
        {
            try
            {
                ComboBox cbx = (ComboBox)control;

                List<string> commandList = new List<string>();

                vkMethods = vk.GetType().GetMethods().ToList();

                foreach (MethodInfo m in vkMethods)
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
        public IEnumerable<string> SendCommand(Control control)
        {
            try
            {
                ComboBox cbx = (ComboBox)control;

                MethodInfo mi = vkMethods.Find(e => e.Name == cbx.SelectedItem.ToString());
                
                return (List<string>)mi.Invoke(vkc, null);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Display text insisde textbox
        /// </summary>
        /// <param name="list">List to display</param>
        /// <param name="control">Textbox for display</param>
        public void FillData(IEnumerable<string> list, Control control)
        {
            string st = String.Empty;
            foreach(string s in list)
            {
                st += s + "\n";
            }

            ((TextBox)control).Text = st;
        }
    }
}
