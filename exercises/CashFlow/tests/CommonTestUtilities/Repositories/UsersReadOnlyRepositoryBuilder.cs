using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Users;
using Moq;

namespace CommonTestUtilities.Repositories;

public class UsersReadOnlyRepositoryBuilder
{
    private readonly Mock<IUsersReadOnlyRepository> _repository;

    public UsersReadOnlyRepositoryBuilder()
    {
        _repository = new Mock<IUsersReadOnlyRepository>();
    }

    public void UserExistsWithEmail(string email)
    {
        _repository
            .Setup(userReadOnlyRepository =>
                userReadOnlyRepository.UserExistsWithEmail(email))
            .ReturnsAsync(true);
    }

    public UsersReadOnlyRepositoryBuilder GetUserByEmail(User user)
    {
        _repository
            .Setup(userReadOnlyRepository =>
                userReadOnlyRepository.GetUserByEmail(user.Email))
            .ReturnsAsync(user);

        return this;
    }

    public IUsersReadOnlyRepository Build() => _repository.Object;
}
