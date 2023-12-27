namespace ProyectoMerck.Helpers
{
    public static class HttpClientHelper
    {

        public static async Task<string> StringFromUrl(string url)
        {

            try
            {
                using (var httpClient = new HttpClient())
                {
                    var result = await httpClient.GetStringAsync(url);

                    return result;
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
