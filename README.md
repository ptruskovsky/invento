# invento

	1) Run keycloak

docker run -p 8080:8080 -e KEYCLOAK_ADMIN=admin -e KEYCLOAK_ADMIN_PASSWORD=admin quay.io/keycloak/keycloak:21.1.1 start-dev

At web console:
 => set init password: "admin" 

Create Realm => "invento"
Realm roles => add roles:
	"projects-manage-all"
	"task-create"
	"task-update"
	"task-query"
	"task-delete"

Clients => Create client => Client Id => "invento"
Clients => Create client => Web origins => "*"

Users => Add User => username "invento", first name "Pavel" (for the test data to be valid)

Users => invento => Tab Credentials => set password  "admin"

Users => invento => Tab Role mapping => map all roles from the  "Realm roles" to the user

Clients => invento => Capability config section => Enable "Direct accesss grants"

	2) Test from Postman:

http://localhost:8080/realms/invento/protocol/openid-connect/token [POST]

type: x-www-form-urlencoded

params: 

clientId : invento
grant_type: password
username: invento
password: admin

There are should be tokes in response

	3) set keys.json as a part of response of http://localhost:8080/realms/invento/protocol/openid-connect/token
	4) open ".sln" file and run the project from Visual Studio just pushing "Play" button, or you can try to build container in Docker and run it from there
	5) no swagger was configured (just default implementation)
