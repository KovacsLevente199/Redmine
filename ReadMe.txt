Ez a fájl tartalmazza a RedMine futtatásához szükséges információkat.

A futtatáshoz szükséges csomagok:
-.NET 8.0
-Microsoft.EntityFrameworkCore (8.0.3)
-Microsoft.EntityFrameworkCore.Sqlite (8.0.3)
-Microsoft.AspNetCore.Authentication.JwtBearer (8.0.3)
-Microsoft.IdentityModel.JsonWebTokens (7.5.1)

---------------------------------------------------------------------------------------------
3.Beadandó

Futtatása:
	
	1.Lépés: El kell indítani a RedMine_backend.sln-t
	2.Lépés: Elindítani https módban a debugot
	3.Megnyitni a RedMine_frontendbe index.html fájlt.

A belépéshez 3 példafelhasználó lett létrehozva:
Felhasználónév |	jelszó
Menedzser2:	pass123 <--Vendég felhasználó
Menedzser1:	pw123 <--admin
Menedzser3:	pword123 <-- admin

Két szerepkör adott:
Vendég: Csak olvashatja az adatokat, nem módosíthat, nem adhat hozzá.
Admin: Ugyanaz mint a vendég, de rendelhet a projektekhez feladatokat.


