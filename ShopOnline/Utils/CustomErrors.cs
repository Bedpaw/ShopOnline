﻿namespace ShopOnline.Utils
{
    public static class CustomErrors
    {
        public const string BusinessLogicError = "This error was generated by business logic.";
        public const string ProductDuplicated = "This product already exists in database.";
        public const string ProductAddError = "Product has been not added.";
        public const string NotExistByGivenId = "Product by given ID does not exist.";
        public const string AddOrderUnable = "The order has not been added to database.";
        public const string AddCustomerError = "The customer with provided data could not have been added.";
        public const string InternalServerError = "Something went wrong. Please contact the Administrator.";
        public const string CustomerByGivenIdNotExists = "The customer with provided Id does not exists.";

        public const int StatusCode450 = 450;
    }
}