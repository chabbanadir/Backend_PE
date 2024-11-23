﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Backend.Application.Features.MasterData.Configurations.Queries.GetConfigurationsByOem;

public class GetConfigurationsByOemQueryValidator : AbstractValidator<GetConfigurationsByOemQuery>
{
    public GetConfigurationsByOemQueryValidator()
    {

        RuleFor(e => e.oemId).MustAsync(async (id, cancellation) =>
        {
            if (!ValidateGuid(id))
            {
                return false;
            }


            return true;
        })
            .WithMessage("The specified Id is not exists.");
    }



    private bool ValidateGuid(string id)
    {
        return Guid.TryParse(id, out var result);
    }
}
