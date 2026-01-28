# Products API – EF Core, TDD & CI

Detta projekt är ett övningsprojekt i .NET med fokus på **ren backend-arkitektur**, **testdriven utveckling (TDD)** och **Continuous Integration (CI)**.

Projektet använder **Entity Framework Core** för dataåtkomst och **InMemory-databas i tester** för snabba, isolerade testkörningar.

---

## Fokus & mål

- Bygga testbar och tydligt strukturerad backend-kod
- Tydlig ansvarsfördelning mellan repository och service
- Skriva meningsfulla tester utan att övertesta ramverk
- Automatiserad kvalitetssäkring med CI

---

## Designval

- Repositories hanterar endast dataåtkomst (CRUD)
- Repositories returnerar `null` vid utebliven data
- Affärsregler och validering ligger i service-lagret
- Tester skrivs enligt TDD-principer

---

## Tester

- xUnit + FluentAssertions
- EF Core InMemory provider
- En isolerad databas per test
- Repository-tester för dataåtkomst
- Service-tester för affärslogik

---

## CI – GitHub Actions

Vid varje push och pull request körs automatiskt:

- `dotnet restore`
- `dotnet build`
- `dotnet test`

Misslyckade tester stoppar bygget och ger snabb feedback.

---

## Tekniker

- .NET / C#
- Entity Framework Core
- xUnit
- FluentAssertions
- GitHub Actions
