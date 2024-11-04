# Kniffel Scoring Service

## Aufgabe

Kniffel ist ein beliebtes Würfelspiel, bei dem es darauf ankommt, durch geschicktes Kombinieren der Augenzahlen möglichst viele Punkte zu erzielen. 

Es soll ein Programm geschrieben werden, dass zu einem gegebenen Wurf mit fünf Würfeln die Kombinationen mit den höchsten Punktzahlen berechnet, damit der Anweder eine davon auf seinen Kniffelblock übernehmen kann.


## Kombinationen

- Einser, Zweier, Dreier, Vierer, Fünfer, Sechser: Für diese Felder wird die Summe der entsprechenden Augenzahlen eingetragen. Zum Beispiel beim Dreier: Wenn Sie eine 3, eine 2 und zwei weitere 3en würfeln, tragen Sie 3+3+3 = 9 Punkte ein.

- Dreierpasch: Für diese Kombination brauchen Sie mindestens dreimal dieselbe Zahl. Alle Augen, auch die Nicht-Dreier- werden anschließend zusammengezählt.

- Viererpasch: Hierfür brauchen Sie mindestens viermal dieselbe Zahl und addieren anschließend auch die Augen des fünften Würfels.

- Beim Full-House zählen Kombinationen aus einmal zwei und einmal drei gleichen Zahlen, z.B. 2+2+3+3+3. 25 Punkte werden in das Feld eintragen, egal welche Augenzahl die Würfel haben.

- Die Kleine Straße benötigt entweder die Würfelkombination von vier aufeinanderfolgenden Zahlen, also von 1 bis 4, von 2 bis 5 oder von 3 bis 6. 30 Punkte werden in das Feld eintragen, wenn Sie die kleine Straße erwürfeln.

- Große Straße: Hierfür brauchen Sie die Würfelkombination von fünf aufeinander folgenden Zahlen, also 1-5 oder 2-6. Dann können Sie 40 Punkte im Spielfeld notieren.

- Der Kniffel ist die am höchst bepunktete Kombination. Hier müssen Sie fünfmal die gleiche Zahl erwürfeln. 50 Punkte können Sie dann in das Feld eingetragen. 

- Bei der Chance muss nichts zusammenpassen. Hier zählt man alle Augen der gewürfelten Würfel querbeet. Deswegen ist es gut, diese aufzusparen. So brauchen Sie keine 0 Punkte im Spielblock eintragen, falls Sie keines der anderen Spielfelder erwürfeln konnten.
