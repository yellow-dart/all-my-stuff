using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Services;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using GamesListWeb.Models;

namespace GamesListWeb
{
    public class GoogleSheetsService
    {
        private readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        private readonly string ApplicationName = "GamesList";
        private readonly string SpreadsheetId = "1KyIQPxSQnvyV__TsFZ7LS3BberIjjS-L-NV0qlJrrLQ";
        private SheetsService service;

        private void SetupCredentials()
        {
            GoogleCredential credential;
            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream)
                    .CreateScoped(Scopes);
            }

            service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
        }

        public string ReadEntries(string sheet, string columnRange)
        {
            SetupCredentials();

            var sheetWithRange = $"{sheet}!{columnRange}";
            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(SpreadsheetId, sheetWithRange);

            
            var response = request.Execute();
            IList<IList<object>> values = response.Values;

            List<Nes> something = Enumerable.Empty<Nes>().ToList();

            if (values != null && values.Count > 0)
            {
                
                foreach (var row in values)
                {
                    var nes = new Nes
                    {
                        Name = row[0].ToString(),
                        NumberOfPlayers = row[1].ToString(),
                        Type = row[2].ToString(),
                        Save = row[3].ToString(),
                        SimultaneousTurn = row[4].ToString(),
                        NumberOfScrews = row[5].ToString(),
                        Instructions = row[6].ToString(),
                        Box = row[7].ToString(),
                        MarkingsEtc = row[8].ToString(),
                        Publisher = row[9].ToString(),
                        Feature = row.Count > 10 ? row[10].ToString() : string.Empty
                    };
                    something.Add(nes);
                }
            }
            return something.ToString();
        }
    }
}
