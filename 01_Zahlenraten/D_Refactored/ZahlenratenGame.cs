using System;

namespace Jarai.Refactoring.Zahlenraten.Refactored
{
    /// <summary>
    ///     Der Computer denkt sich ein zufällige Zahl im Bereich 1 bis 100 aus.
    ///     Nachdem der Anwender einen Tipp eingegeben hat, antwortet der Computer,
    ///     ob der Tipp "Zu klein.", "Zu groß." oder "Richtig!" war.
    ///     Der Anwender muss so lange einen Tipp eingeben, bis er die richtige Zahl erraten hat.
    ///     Der Computer zeigt am Ende an, wieviele Versuche der Anwender benötigt hat.
    /// </summary>
    public class ZahlenratenGame
    {
        private static int _geheimzahl;

        private static IUiService _uiService;

        public ZahlenratenGame(IUiService uiService, int? geheimzahl = null)
        {
            _uiService = uiService;
            _geheimzahl = geheimzahl ?? new Random().Next(1, 101);
        }

        public void Play()
        {
            int anzahlVersuche = 0;
            int eingabezahl;

            do
            {
                _uiService.WriteLine(anzahlVersuche == 0 ? "Errate eine Zahl zwischen 1 und 100" : "Bitte Versuchen sie es erneut");

                 eingabezahl = int.Parse(_uiService.ReadLine());

                 ProzessInput(eingabezahl);

                anzahlVersuche++;

            } while (eingabezahl != _geheimzahl);


            _uiService.WriteLine("du hast" + (anzahlVersuche - 1) + "Versuche gebraucht");
            _uiService.ReadLine();
        }



        public void ProzessInput(int eingabezahl)
        {
            if (eingabezahl < _geheimzahl)
            {
                _uiService.WriteInputToSmall();
            }
            else if (eingabezahl > _geheimzahl)
            {
                _uiService.WriteInputToBig();
            }
            else
            {
                _uiService.WriteInputCorrect();
            }
        }


    }
}