Restaurant Orders API
Ovo je REST API za upravljanje narudžbama restorana, izrađen u ASP.NET Core.
API omogućuje dodavanje, pregled, ažuriranje statusa i sortiranje narudžbi, uz spremanje podataka u SQL bazu.

Funkcionalnosti
 - Dodavanje novih narudžbi
 - Pregled svih narudžbi
 - Pregled pojedinačne narudžbe
 - Mijenjanje statusa narudžbe
 - Automatski izračun ukupnog iznosa narudžbe
 - Sortiranje narudžbi prema ukupnom iznosu

Pokretanje projekta
1. Klonirajte repozitorij te otvorite .sln u Visual Studio
   git clone https://github.com/ivanperisa/restaurant.git

2. Provjerite connection string u appsettings.Development.json
   "ConnectionStrings": {
   	"DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=AbySalto;Trusted_Connection=True;MultipleActiveResultSets=true"
   }

3. Pokrenite migracije
   U Visual Studio: Tools -> NuGet Package Manager -> Package Manager Console
   Pozicionirajte se u restaurant direktorij (korijenski direktorij repozitorija) te u console upišite sljedeće naredbe:
   	Add-Migration InitialCreate
   	Update-Database

4. Pokrenite aplikaciju kao HTTP ili HTTPS
   Otvorite http://localhost:5074 ili https://localhost:7056

Primjeri API poziva
Dodavanje narudžbe (POST /api/order)
{
  "customerName": "Ime Prezime",
  "paymentMethod": 1,
  "deliveryAddress": "Adresa 123, Grad",
  "contactNumber": "123456789",
  "note": "prvi kat",
  "items": [
    { "name": "Burger", "quantity": 2, "price": 6.5 },
    { "name": "Kola", "quantity": 1, "price": 2 }
  ],
  "currency": "EUR"
}

Pregled svih narudžbi (GET /api/order)
Vraća listu svih narudžbi

Promjena statusa narudžbe (PUT /api/order/{id}/status)
U tijelo zahtjeva stavi broj statusa (StatusEnum):
Pending = 1
Preparing = 2
Delivered = 3
Cancelled = 4

PaymentEnum
Cash = 1
CreditCard = 2
DebitCard = 3
BankTransfer = 4
PayPal = 5
Other = 6

Struktura projekta
Models/ – modeli, DTO-ovi i enum-i
Services/ – logika (OrderService)
Controllers/ – RestaurantController
Infrastructure/Database/ – EF Core kontekst i sučelje

Autor
Ivan Periša
ivanperisa@github
https://github.com/ivanperisa
