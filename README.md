# SprConsoleApp

- pro konfigurační soubory vybraný formát json
- k práci s konfiguračními soubory je použit Microsoft.Extensions.Configuration
- zpracování obsahu souborů je implementované v Linq
- všechny soubory json se kopírují do debug složky, k jejich adresaci proto používám relativní cesty

## Náměty ke zlepšení
- parsování souborů pomocí NewtonSoft - hezčí struktura souborů a příjemnější práce se získanými daty 
- doplnění o unit testy
- přesunutí pomocných metod do jiné třídy
- univerzálnější podpora cest k souborům
