----------------------------
---Hur man startar spelet---
----------------------------
Spelet �r gjort f�r operativsystemet Windows 10. 
Ifall du anv�nder ett tidigare Windows operativsystem s� kanske det fungera, om inte s� g�r det att kompilera spelet sj�lv.

Spelet hittas i mappen Spel --> x86 --> Release.

I mappen finns filen GymArbete vilket �r exe-filen till spelet.

Dubbelklicka p� den s� startas spelet. 

F�r att avsluta spelet s� �r det bara att trycka p� escape.
---------------------------
---Hur man spelar spelet---
---------------------------
Spelet spelas med hj�lp utav en numpad. 

Med denna numpad kan man g� �t �tta olika direktioner. 
Sju �r upp �t v�nster, fyra �r v�nster, ett �r ner�t v�nster, alla andra siffrorna f�ljer samma logik


7	8	9
 \      |      /

4 <-           ->6 
  
  /     |      \
1       2       3


Om spelaren �r p� "v�rldskartan" s� kan de trycka p� mellanslag f�r att f� fram en ruta.
I rutan kan man skriva in siffror som �r en seed(om du vill veta vad en seed �r st�r det i gymnasiearbetet).
Ett tryck p� enter finaliserar seeden och en ny v�rld laddas fram. 
Samma v�rld genereras med samma seed. 

F�r att g� fr�n v�rldkartan till den rumbaserade delen av spelet s� �r det bara att trycka p� numpadens plusknapp.

I den rumbaserade delen av spelet s� g�r man runt p� samma s�tt.

Skillnaden in detta fall �r att det finns trappor spelaren kan g� upp och ner i.

F�r att g� upp en v�ning trycker man p� plusknappen, f�r att g� ner anv�nds minus.
Detta fungerar endast om spelkarakt�ren st�r p� r�tt sorts trappa.

----------------------------
---Kompilera spelet sj�lv---
----------------------------

F�r att smidigt kunna kompilera koden sj�lv beh�vs Visual Studio och Monogame.

VISUAL STUDIO: https://visualstudio.microsoft.com/downloads/

MONOGAME: http://www.monogame.net/

N�r b�da programmen �r installerade p� datorn s� �r det bara att �ppna GymArbete.sln filen i GymArbete mappen.

Ifall b�da programmen installerades korrekt s� ska det bara vara att trycka p� "Build". 

-------------------
---L�s k�llkoden---
-------------------

Denna del �r mest till f�r de som inte har Visual Studio och Monogame d� de smidigt kan kolla k�llkoden genom GymArbete.sln filen.
Kolla under "Kompilera spelet sj�lv" f�r mer information om detta.

Mappen f�r all k�llkod hittas i GymArbete --> GymArbete.

Alla .cs filer i den mappen �r dokument jag sj�lv skrivit. 

Sub-mapparna: Worldloading, Main och Blocks; inneh�ller alla filer enbart skrivna av mig.

I sub-mappen Content hittas alla bildfiler och typsnitt projektet anv�nder sig av.
