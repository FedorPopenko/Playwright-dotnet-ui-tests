namespace UiTestsPlaywright.Core
{
    public static class TestData
    {
        public const string BaseUrl = "https://www.saucedemo.com/";

        public const string StandardUser = "standard_user";
        public const string Password = "secret_sauce";
        public const string WrongUser = "wrong_user";
        public const string WrongPassword = "wrong_password";

        public const string FirstName = "John";
        public const string LastName = "Doe";
        public const string PostalCode = "12345";
        public const string ErrorFirstName = "Error: First Name is required";
        public const string ErrorLastName = "Error: Last Name is required";
        public const string ErrorPostalCode = "Error: Postal Code is required";

        public static readonly Product Backpack = new Product("Sauce Labs Backpack", "sauce-labs-backpack");
        public static readonly Product BikeLight = new Product("Sauce Labs Bike Light", "sauce-labs-bike-light");
        public static readonly Product BoltTShirt = new Product("Sauce Labs Bolt T-Shirt", "sauce-labs-bolt-t-shirt");
        public static readonly Product FleeceJacket = new Product("Sauce Labs Fleece Jacket", "sauce-labs-fleece-jacket");
        public static readonly Product Onesie = new Product("Sauce Labs Onesie", "sauce-labs-onesie");
        public static readonly Product RedTShirt = new Product("Test.allTheThings() T-Shirt (Red)", "test.allthethings()-t-shirt-(red)");
    }
}
