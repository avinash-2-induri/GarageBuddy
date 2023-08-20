﻿namespace GarageBuddy.Common.Constants
{
    public static class MessageConstants
    {
        public const string NotDeleted = "Not deleted";

        public static class Errors
        {
            public const string GeneralError = "Something went wrong!";

            public const string NoEntityWithPropertyFound = "Entity {0} with property {1} was not found!";

            public const string NoEntityWithPropertyValuesFound = "Entity {0} with property {1} and value {2} was not found!";

            public const string DeserializationFailed = "Deserialization of the file {0} failed!";

            public const string InvalidDirectoryPath = "Invalid directory path!";

            public const string CannotBeNullOrWhitespace = "{0} cannot be null or whitespace.";

            public const string InvalidUsernameOrPassword = "Invalid username or password.";

            public const string AccountLockedOut = "Account locked out. Try again later";

            public const string PasswordsDoNotMatch = "Passwords do not match.";

            public const string SomethingWentWrong = "Something went wrong. Please try again later.";

            public const string GeneralErrorSendEmail = "Errors occured while sending email.";

            public const string EntityModelStateIsNotValid = "{0} model state is not valid.";

            public const string EntityNotFound = "The {0} cannot be found.";

            public const string EntityCannotBeNull = "The {0} cannot be null.";

            public const string EntityNotCreated = "The {0} cannot be created.";

            public const string InvalidValue = "Invalid value";

            public const string EntityRelationsAreNotValid = "The {0} relations are not valid.";

            public const string EntityWithTheSameNameAlreadyExists = "The {0} with the same name ({1}) already exists.";

            public const string EntityDoesNotExist = "The {0} does not exist.";

            public const string InvalidCoordinates = "Invalid coordinates.";

            public const string SourceOrDestinationNull = "Source or/and Destination Objects are null";

            public const string NoMoreThanOneActiveGarage = "There can be only one active garage. Deactivate the other one.";

            public const string NoValidGarageCoordinates = "No valid garage coordinates found.";
        }

        public static class Success
        {
            public const string PasswordResetMailSent = "Password Reset Mail has been sent to your Email {0}.";

            public const string SendPasswordResetEmail =
                "Please check your email for a link to reset your password. If it doesn't appear within a few minutes, check your spam folder.";

            public const string PasswordResetSuccessful = "Password Reset Successful!";

            public const string SuccessfullyCreatedEntity = "Successfully created {0}.";

            public const string SuccessfullyEditedEntity = "Successfully edited {0}.";
        }
    }
}
