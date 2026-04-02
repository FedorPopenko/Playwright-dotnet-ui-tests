# Playwright .NET UI Tests

Automated UI testing framework for the SauceDemo web application using C#, Playwright, and NUnit.  
The project implements Page Object Model (POM) and covers core user scenarios.

---

## 🛠 Tech Stack

- C#
- .NET 8
- Playwright
- NUnit
- Page Object Model (POM)
- Git & GitHub

---

## 🚦 Project Status

**Active development**

**Implemented:**
- Login page tests
- Inventory page tests
- Cart page tests
- Checkout flow
- E2E test
- Smoke tests
- Test data separation
- Parallel test execution

**In progress:**
- CI integration
- Screenshots & reporting

---

## 📑 Test Scenarios

### 🔹 Login
- Login with empty username/password
- Login with valid credentials

### 🔹 Inventory
- Add product to cart  
- Remove product  
- Verify product visibility  
- Add multiple products  

### 🔹 Cart
- Verify product in cart  
- Remove product from cart  
- Validate cart content  

### 🔹 Checkout
- Form validation (negative tests)  
- Successful checkout step transition  

### 🔹 End-to-End
- Full purchase flow

---

## 🗂 Project Structure

```
UiTestsPlaywright/
├── Core/
│   ├── AssemblyInfo.cs 
│   ├── BaseTest.cs
│   ├── Product.cs
│   └── TestData.cs
├── Pages/
│   ├── CheckoutPage/
│   │   ├── CheckoutStepOnePage.cs
│   │   ├── CheckoutOverviewPage.cs
│   │   └── CheckoutCompletePage.cs
│   ├── CartPage.cs 
│   ├── InventoryPage.cs
│   └── LoginPage.cs
└── Tests/
    ├── CartTests.cs 
    ├── CheckoutTests.cs
    ├── E2ETests.cs
    ├── InventoryTests.cs
    ├── LoginTests.cs
    └── SmokeTests.cs

```