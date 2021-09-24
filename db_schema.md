# Database Schema

- Peep (<ins>Id</ins>, First Name, Middle Name, Last Name, Short Description, Long Description)

This table represents a highlighted person.  There are general details for a person and a short and long bio for them as well. 

- Users (<ins>id</ins>, peepId, username, password) 
    - Foreign key peepId references Peeps

This table represents a registered user and stores credentials.

- Image (<ins>Id</ins>, PeepId, URL, Title, Caption, IsProfile)
    - Foreign Key PeepId references Peep

This table represents images attached to a Peep.  The columns involve metadata and a foreign key to relate an image to a Peep.

- Works (<ins>Id</ins>, PeepId, Type, Description, URL, Title)
    - Foreign Key PeepId references Peep

Works describe various fields below a Peep highlighting specific achievements, publications, or important events for the Peep.  These sub-categories are generalized as works, with the “Type” column representing an enum that will distinguish the type of work and what group it will be shown on screen under.  

- Follows (<ins>followerId</ins>, <ins>followeeId</ins>) 
    - Foreign key followerId references Users 
    - Foreign key followeeId references Peeps

For the social media aspect of the app, users will be allowed to follow a certain Peep's page.  Two foreign keys create the composite key for this table relating a user to a Peep.