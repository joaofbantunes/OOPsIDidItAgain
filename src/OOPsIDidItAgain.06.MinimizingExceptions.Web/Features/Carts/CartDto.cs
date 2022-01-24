using OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Features.Carts;

public record CartDto(CartId Id, IEnumerable<CartItemDto> Items);
