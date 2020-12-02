﻿using System;
using FluentValidation;

namespace EventsExpress.ViewModels
{
    public class EventCreateViewModelValidator : AbstractValidator<EventCreateViewModel>
    {
        public EventCreateViewModelValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Field is required!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Field is required!");
            RuleFor(x => x.DateFrom).NotEmpty().WithMessage("Field is required!");
            RuleFor(x => x.DateFrom).GreaterThanOrEqualTo(DateTime.Today).WithMessage("date from must be older than date now!");
            RuleFor(x => x.DateTo).NotEmpty().WithMessage("Field is required!");
            RuleFor(x => x.User).NotNull().WithMessage("User does not exist!");
            RuleFor(x => x.MaxParticipants).GreaterThan(0).WithMessage("Input correct quantity of participants!");
            RuleFor(x => x.Categories).NotEmpty().WithMessage("List of Categories is empty!");
        }
    }
}
