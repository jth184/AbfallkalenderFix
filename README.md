# AbfallkalenderFix
Der Landkreis Gifhorn stellt auf der Seite abfallkalender-gifhorn.de den Abfallkalender für den Landkreis als ics Datei bereit.
Die jeweiligen Termin sind in der Datei nicht entsprechend RFC 5545 eingetragen, da Start- und Enddatum identisch sind.
Das Programm liest die Termine ein und addiert jeweils zum Enddatum einen Tag. Somit werden die Termine korrekt als ganztägiger Termin
importiert. Zusätzlich kann jeder Termin mit einer Erinnerung versehen werden. Die Erinnerung muss in Stunden vor Termin eingetragen werden (von Mitternacht rückwärts).
Für eine Erinnerung z.B. um 17 Uhr daher -7 Stunden einstellen.

Das Programm kann [hier](/Release/Release_1.0.0.zip) heruntergeladen werden.
