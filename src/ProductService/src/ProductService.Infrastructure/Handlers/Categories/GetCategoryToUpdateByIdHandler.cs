﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Mapster;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.Repositories;
using ProductService.Contracts.Dtos.Categories;
using ProductService.Infrastructure.Requests.Categories;

namespace ProductService.Infrastructure.Handlers.Categories;

public sealed record GetCategoryToUpdateByIdHandler : IActionRequestHandler<GetCategoryToUpdateByIdRequest>
{
    private readonly ICategoryRepo _categoryRepo;

    public GetCategoryToUpdateByIdHandler(ICategoryRepo categoryRepo)
    {
        _categoryRepo = categoryRepo;
    }

    public async ValueTask<IActionResult> Handle(GetCategoryToUpdateByIdRequest request,
        CancellationToken cancellationToken)
    {
        var category = await _categoryRepo.GetByIdAsync(request.Id, cancellationToken);
        return new OkObjectResult(category.Adapt<CategoryDto>());
    }
}
