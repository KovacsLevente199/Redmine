Ez a fájl tartalmazza a RedMine futtatásához szükséges információkat.

A futtatáshoz szükséges csomagok:
-.NET 8.0
-Microsoft.EntityFrameworkCore (8.0.3)
-Microsoft.EntityFrameworkCore.Sqlite (8.0.3)


---------------------------------------------------------------------------------------------
1.Beadandó 
Futtatása:
	
	1.Lépés: El kell indítani a RedMine_backend.sln-t
	2.Lépés: Elindítani https módban a debugot
	3.Megnyitni a RedMineTestPage.html-t

Megfelelő működés esetén a gombokra kattintva a kliens küld egy lekérést a szerver felé
ami JSON formátumba visszaküld egy próbadatokkal teli objektumot.
Ezt a választ a kliens megjelenití, és kiirja a próbaadatokat JSON formátumba.
Ha bármilyen okból egy esetleges hiba fellép a kommunikáció során akkor egy "ERROR:Failed to fetch" üzenettel tér vissza.

Minden egyes gomb egy végpontnak felel meg a szerveren pl a "loadinitial" gomb a "https://localhost:7295/RedMineDataList/loadinitial" szerveroldali API végpontnak felel meg.
---------------------------------------------------------------------------------------------
