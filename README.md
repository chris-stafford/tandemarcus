# Overview
## Tandem Diabetes ARCUS Backend Coding Excercise
API for accessing users and notes.

## API

* `GET /health` Health check

* `GET /user/{user-id}/note` Retrieve notes for user

* `POST /user/{user-id}/note` Add a user note

* `GET /user` Retrieve a user by email

* `POST /user` Add a user

## Try it out

`dotnet run`

## Notes

### The Notes entity was added due to a misreading of the requirements.

In the instructions, there is a subheading labled *Get notes*, which means "notes about GET functionality for Users". I, for some reason, intrepreted it to mean *GET Notes*, with Notes being a separate entity to be logically implemented.  I realized I had misread things at some point, but I didn't see any reason to remove the work I had done, so there's an extra entity and related functionality in what I'm submitting.

## Time spent

I stopped at exactly 4 hours of work. Github reports 8 hours between the initial commit and my last one, but half of that time was spent away from my machine.

## 3rd Party Libraries Used

### Web API
* AutoMapper
* Mediatr
* Serilog
* Swashbuckle
* FluentValidation

### Testing
* xunit
* Moq (and MockQueryable)
* AutoFixture


Thank you,

--Chris Stafford
