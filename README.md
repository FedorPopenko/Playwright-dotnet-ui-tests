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
- Add/Remove products from cart
- Cart badge validation

**In progress:**
- Checkout flow
- Test data separation
- CI integration
- Screenshots & reporting

---

## 📑 Test Scenarios

- Login with empty username/password
- Login with valid credentials
- Product visibility check
- Add product to cart
- Remove product from cart
- Multiple products cart count validation

---

## 🗂 Project Structure

UiTestsPlaywright
- ├── Tests # Test classes
- ├── Pages # Page Objects
- ├── Core # BaseTest, helpers, config
