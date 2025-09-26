# GroceryApp 

## Gitflow:  
Ik maak gebruik van deze branch structuur:
```
Main
└── Dev
	└──Feature/...
└──Hotfix/...
```

In commit messages gebruik ik een vaste template:  
*voorbeelden:*
```
feat(client): add EmailAddress and Password properties
fix(login): verify password using PasswordHelper
docs(readme): add GitFlow structure with emojis
```
De commit message bestaat uit vaste onderdelen:
```
<type>(<wat>): <korte omschrijving>
```
Types:
| Type     | Wat is het?                                    | Branch          |
| -------- | ---------------------------------------------- | --------------- |
| update   | groote update van dev -> main                  | main            |
| hotfix   | hotfix                                         | main/hotfix/... |
| feat     | nieuwe feature                                 | dev/feature/... |
| bugfix   | bugfix                                         | dev/bugfix/...  |
| docs     | documentatie                                   | dev/docs/...    |
| test     | toevoegen / aanpassen van tests                | dev/test/...    |
| style    | format, linting, whitespace                    | dev/style/...   |
| refactor | code refactor (geen nieuwe feature / geen bug) | dev             |  

## Use cases:  
### UC01 Tonen boodschappenlijsten  
Is compleet.

### UC02 Tonen inhoud boodschappenlijst  
In het bestand `GroceryListItem.cs` uit het project Grocery.Core.Models:
- De member variabelen wijzigen in properties
- In de constructor de doorgegeven waarden koppelen aan de properties.

### UC03 Tonen producten 
In het bestand `ProductRepository.cs` uit het project Grocery.Core.Data:
- Initieer in de constructor de lijst met 4 nieuwe producten:  
  - Melk[voorraad 300]
  - Kaas[voorraad 100]
  - Brood[voorraad 400]
  - Cornflakes[voorraad 0]
- In de methode `GetAll()` zorg je dat de lijst met producten wordt meegegeven.

### UC04 Kiezen kleur boodschappenlijst  
Is compleet.

### UC05 Product op boodschappenlijst plaatsen   
- `GetAvailableProducts()`  
	De header van de functie bestaat maar de inhoud niet.  
	Zorg dat je een lijst maakt met de beschikbare producten (dit zijn producten waarvan nog voorraad bestaat en die niet al op de boodschappenlijst staat).  
- `AddProduct()`   
	Zorg dat het gekozen beschikbare product op de boodschappenlijst komt (door middel van de GroceryListItemsService).  

### UC06 Inloggen  
Een collega is ziek maar heeft al een deel van de inlogfunctionaliteit gemaakt.  
Dit betreft het Loginscherm (LoginView) met bijbehorend ViewModel (LoginViewModel),  
maar ook al een deel van de authenticatieService (AuthServnn,mnmice in Grocery.Core),  
de clientrepository (ClientRepository in Grocery.Core.Data)  
en de client class (Client in Grocery.Core).  
De opdracht is om zelfstandig de login functionaliteit te laten werken.  

*Stappenplan:*  
1. Begin met de Client class en zorg dat er gebruik wordt gemaakt van Properties.  
2. In de ClienRepository wordt nu steeds een vaste client uit de lijst geretourneerd. Werk dit uit zodat de juiste Client wordt geretourneerd.  
3. Werk de klasse AuthService verder uit, zodat daadwerkelijk de controle op het ingevoerde password wordt uitgevoerd.
4. Zorg dat de `LoginView.xaml` wordt toegevoegd aan het Grocery.App project in de Views folder (Add ExistingItem). De file bevindt zich al op deze plek, maar wordt nu niet meegecompileerd.  
5. In MauiProgramm class van de Grocery.App staan de registraties van de AuthService en de LoginView in comment --> haal de // weg.  
6. In `App.xaml.cs` staat /*LoginViewModel viewModel*/ haal hier /* en */ weg, zodat het LoginViewModel beschikbaar komt.  
7. In `App.xaml.cs` staat //MainPage = new LoginView(viewModel); Haal hier de // weg en zet de regel erboven in commentaar, zodat AppShell wordt uitgeschakeld.  
8. Uncomment de route naar het Login scherm in `AppShell.xaml.cs`: //Routing.RegisterRoute("Login", typeof(LoginView));

### UC07 Delen boodschappenlijst
Is compleet

### UC08 Zoeken producten  
- In de `GroceryListItemsView` zitten twee Collection Views, namelijk één voor de inhoud van de boodschappenlijst en één voor producten die je toe kunt voegen aan de boodschappenlijst
- Voeg boven de tweede CollectionView een zoekveld (SearchBar) in om op producten te kunnen zoeken.
- Zorg dat de SearchCommand wordt gebonden aan een functie in het onderliggende ViewModel (GroceryListItemsViewModel) en dat de zoekterm die in het zoekveld is ingetypt gebruikt wordt als parameter (SearchCommandParameter).
- Werk in het viewModel (GroceryListItemsViewModel) de zoekfunctie uit en zorg dat de beschikbare producten worden gefilterd op de zoekterm!  

### UC9 Registratie gebruiker
Of een ander idee zelf uitwerken. Dit betekent ook dat de documentatie hiervoor ontwikkeld moet worden.
