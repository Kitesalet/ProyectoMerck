namespace ProyectoMerck.Helpers
{
    public static class HttpClientHelper
    {

        public static string StringFromUrl(string url)
        {

            try
            {
                using (var httpClient = new HttpClient())
                {
                    return httpClient.GetStringAsync(url).Result;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return "Invalid Url";
            }

        }


    }
}
