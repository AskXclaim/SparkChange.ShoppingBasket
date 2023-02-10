// Global using directives

global using System.Net;
global using AutoMapper;
global using MediatR;
global using Microsoft.AspNetCore.Mvc;
global using ShoppingBasket.Api.Middleware;
global using ShoppingBasket.Api.Models;
global using ShoppingBasket.Api.Models.Basket;
global using ShoppingBasket.Api.Shared;
global using ShoppingBasket.Application;
global using ShoppingBasket.Application.CustomException;
global using ShoppingBasket.Application.Features.Basket.Commands.RemoveItem;
global using ShoppingBasket.Application.Features.Basket.Commands.RemoveItems;
global using ShoppingBasket.Application.Features.Basket.Commands.UpsertBasket;
global using ShoppingBasket.Application.Features.Basket.Queries;
global using ShoppingBasket.Application.Features.Basket.Queries.GetBasketItem;
global using ShoppingBasket.Application.Features.Basket.Queries.GetBasketItems;
global using ShoppingBasket.Application.Features.Item.Queries.GetItemDetails;
global using ShoppingBasket.Application.Features.Item.Queries.GetItems;
global using ShoppingBasket.Persistence;