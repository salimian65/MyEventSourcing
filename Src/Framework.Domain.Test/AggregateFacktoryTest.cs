using System;
using System.Collections.Generic;
using FizzWare.NBuilder;
using FluentAssertions;
using Xunit;

namespace Framework.Domain.Test
{
    public class AggregateRootTests
    {
        [Fact]
        public void EventApply_Should_Arrive_To_The_LastState()
        {
            //---------Load & Replay Envents
            var userRegistered = new UserRegistered(1, "Admin", "John", "Doe");
            var userActivated = new UserActivated(1);

            var user = new User();
            user.Apply(userRegistered);
            user.Apply(userActivated);


            user.UserName.Should().Be("Admin");
            user.FirstName.Should().Be("John");
            user.LastName.Should().Be("Doe");
            user.IsActive.Should().BeTrue();
        }

        [Fact]
        public void creates_Aggregate_by_Applying_events()
        {
            //---------Load & Replay Envents
            var events = new List<DomainEvent>
            {
                new UserRegistered(1,"Admin", "John", "Doe"),
                new UserActivated(1),
                new UserPersonalInfoUpdated("Jack","Doe"),
            };

            var factory = new AggregateFactory();
            var user = factory.Create<User>(events);
            user.IsActive.Should().BeTrue();
            user.FirstName.Should().Be("Jack");
            user.LastName.Should().Be("Doe");

        }

        public void creates_Aggregate_by_Applying_events1()
        {
            //---------Load & Replay Envents
            var events = new List<DomainEvent>
            {
                new UserRegistered(1,"Admin", "John", "Doe"),
                new UserActivated(1),
              //  new UserPersonalInfoUpdated("Jack","Doe"),
            };

            var ddd = Builder<UserPersonalInfoUpdated>.CreateListOfSize(1000);


            var factory = new AggregateFactory();
            var user = factory.Create<User>(events);
            user.IsActive.Should().BeTrue();
            user.FirstName.Should().Be("Jack");
            user.LastName.Should().Be("Doe");

        }

        public class User : AggregateRoot<long>
        {

            public string UserName { get; private set; }

            public string FirstName { get; private set; }

            public string LastName { get; private set; }

            public bool IsActive { get; private set; }

            public bool IsEmailConfirmed { get; private set; }

            public void Activate()
            {
                if (IsEmailConfirmed)
                {
                    throw new Exception("xxxxxxx");
                }

                ApplyAndPublish(new UserActivated(Id));

            }

            public void UpdatePersonalInFo(string firstName, string lastName)
            {
                if (!IsActive)
                {
                    throw new Exception("  dddd");
                }

                ApplyAndPublish(new UserPersonalInfoUpdated(firstName, lastName));
            }


            protected override void When(DomainEvent @event)
            {
                When((dynamic)@event);
            }

            private void When(UserRegistered @event)
            {
                this.FirstName = @event.FirstName;
                this.UserName = @event.UserName;
                this.LastName = @event.LastName;
                this.IsActive = false;
            }

            private void When(UserActivated @event)
            {
                this.IsActive = true;
            }

            private void When(UserPersonalInfoUpdated @event)
            {
                FirstName = @event.FirstName;
                LastName = @event.LastName;
            }
        }

        public class UserRegistered : DomainEvent
        {
            public UserRegistered(long id, string userName, string firstName, string lastName)
            {
                Id = id;
                UserName = userName;
                FirstName = firstName;
                LastName = lastName;
            }

            public long Id { get; private set; }

            public string UserName { get; private set; }

            public string FirstName { get; private set; }

            public string LastName { get; private set; }
        }

        public class UserPersonalInfoUpdated : DomainEvent
        {
            public UserPersonalInfoUpdated(string firstName, string lastName)
            {
                FirstName = firstName;
                LastName = lastName;
            }

            public string FirstName { get; private set; }

            public string LastName { get; private set; }
        }

        public class UserActivated : DomainEvent
        {
            public UserActivated(long userId)
            {
                Id = userId;
            }

            public long Id { get; private set; }
        }
    }
}
