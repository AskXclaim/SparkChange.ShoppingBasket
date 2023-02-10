// Global using directives

global using System.Reflection;
global using System.Text.Json.Serialization;
global using AutoMapper;
global using FluentValidation;
global using FluentValidation.Results;
global using MediatR;
global using Microsoft.Extensions.DependencyInjection;
global using ShoppingBasket.Application.Contracts.CurrencyConverter;
global using ShoppingBasket.Application.Contracts.Persistence;
global using ShoppingBasket.Application.Contracts.Persistence.Basket;
global using ShoppingBasket.Application.Contracts.Persistence.Item;
global using ShoppingBasket.Application.CustomException;
global using ShoppingBasket.Application.Features.Basket.Commands.RemoveItem;
global using ShoppingBasket.Application.Features.Basket.Common;
global using ShoppingBasket.Application.Features.Basket.Queries;
global using ShoppingBasket.Application.Features.Item.Queries.GetItemDetails;
global using ShoppingBasket.Application.Features.Item.Queries.GetItems;
global using ShoppingBasket.Domain.Basket;
global using ShoppingBasket.Domain.Item;