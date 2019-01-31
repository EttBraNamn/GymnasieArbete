----------------------------
---Hur man startar spelet---
----------------------------
Spelet startar för alla med operativsystemet Windows 10

Speler hittas i mappen Spel --> x86 --> Release.

I mappen finns filen GymArbete vilket är exe-filen till spelet.

Dubbelklicka på den så startas spelet. 

För att avsluta spelet så är det bara att trycka på escape.
---------------------------
---Hur man spelar spelet---
---------------------------
Spelet spelas med hjälp utav en numpad. 

Med denna numpad kan man då gå åt åtta olika direktioner. 
Sju är upp åt vänster, fyra är vänster, ett är neråt vänster. Alla andra siffrorna följer samma logik

Om spelaren är på "världskartan" så kan de trycka på mellanslag för att få fram en ruta.
I rutan kan man skriva in siffror som är en seed(om du vill veta vad en seed är står det i gymnasiearbetet).
Ett tryck på enter finaliserar seeden och en ny värld laddas fram. 
Samma värld genereras med samma seed varje gång. 

För att gå från världkartan till den rumbaserade delen av spelet så är det bara att trycka på numpadens plusknapp.

I den rumbaserade delen av spelet så går man runt på samma sätt.

Skillnaden in detta fall är att det finns trappor spelaren kan gå upp och ner genom.

För att gå upp en våning trycker man på plusknappen, för att gå ner används minus.
Detta fungerar endast om spelkaraktären står på rätt sorts trappa.

----------------------------
---Kompilera spelet själv---
----------------------------

För att smidigt kunna kompilera koden själv behövs Visual Studio och Monogame.

VISUAL STUDIO: https://visualstudio.microsoft.com/downloads/

MONOGAME: http://www.monogame.net/

När båda programmen är installerade på datorn så är det bara att öppna GymArbete.sln filen i GymArbete mappen.

Ifall båda programmen installerades korrekt så ska det bara vara att trycka på "Build". 

-------------------
---Läs källkoden---
-------------------

Denna del är mest till för de som inte har Visual Studio och Monogame då de smidigt kan kolla källkoden genom GymArbete.sln filen.
Kolla under "Kompilera spelet själv" för mer information om detta.

Mappen för all källkod hittas i GymArbete --> GymArbete.

Alla .cs filer i den mappen är dokument jag själv skrivit. 

Sub-mapparna: Worldloading, Main och Blocks; innehåller alla filer enbart skrivna av mig. 