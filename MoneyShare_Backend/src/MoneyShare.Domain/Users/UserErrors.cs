﻿using SharedKernel;

namespace MoneyShare.Domain.Users;

public static class UserErrors
{
    public static Error NotFound(Guid userId) => Error.NotFound(
        "Users.NotFound",
        $"The user with the Id = '{userId}' was not found");

    public static Error NotFoundByEmail => Error.NotFound(
    "Users.NotFoundByEmail",
    "The user with the specified email was not found");
}
