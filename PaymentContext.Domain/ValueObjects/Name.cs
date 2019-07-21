using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects {
    public class Name : ValueObject {
        public Name (string firstName, string lastName) {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications (new Contract ()
                .Requires ()
                .HasMinLen (FirstName, 3, "Name.FirstName", "Nome deve conter pelo menos 3 caracteres")
                .HasMinLen (LastName, 3, "Name.FirstName", "Sobrenome deve conter pelo menos 3 caracteres")
                .HasMaxLen (FirstName, 30, "Name.FirstName", "Nome deve ter no máximo 30 caracteres")
                .HasMaxLen (LastName, 30, "Name.FirstName", "Sobrenome deve ter no máximo 30 caracteres")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}