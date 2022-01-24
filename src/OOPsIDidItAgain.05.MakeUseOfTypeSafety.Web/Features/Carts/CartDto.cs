using OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Domain;

namespace OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Models;

public record CartDto(CartId Id, IEnumerable<CartItemDto> Items);
