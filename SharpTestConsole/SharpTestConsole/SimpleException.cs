using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

namespace Google.Apis.YouTube.Samples
{
    
    /// <summary>
    /// YouTube Data API v3 sample: create a playlist.
    /// Relies on the Google APIs Client Library for .NET, v1.7.0 or higher.
    /// See https://developers.google.com/api-client-library/dotnet/get_started
    /// </summary>
    internal class PlaylistUpdates
    {   
        [STAThread]
        static void Main(string[] args)
        {
            List<int> lst = new List<int> { 3, 23, 23, 56, 5, 7, 9, 2, 5, 78, 98, 54, 32, 545 };
            lst.RemoveAll(x => x < 50);
            

            Console.WriteLine("YouTube Data API: Playlist Updates");
            Console.WriteLine("==================================");

            try
            {
                new PlaylistUpdates().Run().Wait();
            }
            catch (AggregateException ex)
            {
                foreach (var e in ex.InnerExceptions)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private async Task Run()
        {
            LiveChatMessage df = new LiveChatMessage();
            
            UserCredential credential;
            using (var stream = new FileStream("secr1.json", FileMode.Open, FileAccess.ReadWrite))
            {
                //var stream = new FileStream("secr.json", FileMode.Open, FileAccess.ReadWrite);

                byte[] com;
                com = new byte[stream.Length];
                stream.Seek(0, SeekOrigin.Begin);
                for (int i = 0; i < com.Length; i++)
                    com[i] = (byte)stream.ReadByte();
                
                com = ChangeEveryNByte(3, com);
                stream.Seek(0, SeekOrigin.Begin);

                stream.Write(com, 0, com.Length);
                stream.Seek(0, SeekOrigin.Begin);

                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    // This OAuth 2.0 access scope allows for full read/write access to the
                    // authenticated user's account.
                    new[] { YouTubeService.Scope.Youtube },
                    "user",
                    CancellationToken.None,
                    new FileDataStore(this.GetType().ToString())
                );

                var st = new FileStream("secr1.json", FileMode.Open, FileAccess.ReadWrite);
                com = ChangeEveryNByte(3, com);                

                st.Write(com, 0, com.Length);

                st.Close();                
            }
            
           
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = this.GetType().ToString()
            });
            
            // Create a new, private playlist in the authorized user's channel.
            var newPlaylist = new Playlist();
            newPlaylist.Snippet = new PlaylistSnippet();
            newPlaylist.Snippet.Title = "Test Playlist";
            newPlaylist.Snippet.Description = "A playlist created with the YouTube API v3";
            newPlaylist.Status = new PlaylistStatus();
            newPlaylist.Status.PrivacyStatus = "public";
            newPlaylist = await youtubeService.Playlists.Insert(newPlaylist, "snippet,status").ExecuteAsync();

            // Add a video to the newly created playlist.
            var newPlaylistItem = new PlaylistItem();
            newPlaylistItem.Snippet = new PlaylistItemSnippet();
            newPlaylistItem.Snippet.PlaylistId = newPlaylist.Id;
            newPlaylistItem.Snippet.ResourceId = new ResourceId();
            newPlaylistItem.Snippet.ResourceId.Kind = "youtube#video";
            newPlaylistItem.Snippet.ResourceId.VideoId = "GNRMeaz6QRI";
            newPlaylistItem = await youtubeService.PlaylistItems.Insert(newPlaylistItem, "snippet").ExecuteAsync();

            Console.WriteLine("Playlist item id {0} was added to playlist id {1}.", newPlaylistItem.Id, newPlaylist.Id);
        }
        static byte[] ChangeEveryNByte(byte n, byte[] a)
        {
            byte[] ret = new byte[a.Length];
            int by = 0;
            foreach (byte c in a)
            {
                ret[by] = c;
                for (int i = 0; i < 8; i++)
                {
                    if ((i % n == 0) && (i > 0))
                    {
                        byte v = (byte)Math.Pow(2, i - 1);
                        byte tb = (byte)(c & (byte)v);
                        if (tb == v)
                            ret[by] = (byte)(ret[by] & (255 - v));
                        else
                            ret[by] = (byte)(ret[by] | v);
                    }
                }
                by++;
            }
            return ret;
        }
    }
    internal class Testing
    {        
        static void Main()
        {
            byte[] b = new byte[] { 0x12, 0x23, 0x34, 0x45, 0x56, 0x67, 0x78, 0x89 };
            byte[] c = new byte[] { 0x98, 0x87, 0x76, 0x65, 0x54, 0x43, 0x32, 0x21 };

            byte[] com;

            var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.ReadWrite);
            com = new byte[stream.Length];
            for (int i = 0; i < com.Length; i++)
                com[i] = (byte)stream.ReadByte();
            stream.Close();

           // com = ChangeEveryNByte(3, com);

            //stream = new FileStream("secr.json", FileMode.Open, FileAccess.Read);
            //com = new byte[stream.Length];
            //for (int i = 0; i < com.Length; i++)
            //    com[i] = (byte)stream.ReadByte();
            //com = ChangeEveryNByte(3, com);
            //stream.Flush();
            //stream.Write(com, 0, com.Length);
                        
            //stream.Close();


            com = ChangeEveryNByte(3, com);


            stream = new FileStream("secr1.json", FileMode.Create, FileAccess.ReadWrite);
            stream.Write(com, 0, com.Length);
            stream.Close();

            Console.ReadLine();
        }        

        static byte[] ChangeEveryNByte(byte n, byte[] a)
        {
            byte[] ret = new byte[a.Length];            
            int by = 0;
            foreach (byte c in a)
            {
                ret[by] = c;
                for (int i = 0; i < 8; i++)
                {
                    if ( (i % n == 0) && (i > 0))
                    {
                        byte v = (byte)Math.Pow(2, i - 1);
                        byte tb = (byte)(c & (byte)v);
                        if (tb == v)
                            ret[by] = (byte)(ret[by] & (255 - v));
                        else
                            ret[by] = (byte)(ret[by] | v);
                    }
                }
                by++;
            }
            return ret;
        }

        static string ChangeEveryNString(byte n, string a)
        {
            char[] ch = a.ToCharArray();
            char[] ret = new char[ch.Length];
            int by = 0;
            foreach (char c in ch)
            {
                ret[by] = c;
                for (int i = 0; i < 8; i++)
                {
                    if ((i % n == 0) && (i > 0))
                    {
                        byte v = (byte)Math.Pow(2, i - 1);
                        char tb = (char)(c & v);
                        if (tb == v)
                            ret[by] = (char)(ret[by] & (255 - v));
                        else
                            ret[by] = (char)(ret[by] | v);
                    }
                }
                by++;
            }
            return new string(ret);
        }
    }
}