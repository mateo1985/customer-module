curl -X PUT \
  http://localhost:5000/Customer \
  -H 'content-type: application/json' \
  -d '{
	"Name": "ExampleName1",
	"Surrname": "ExampleSurrname2",
	"Telephone": "+481231231",
	"Address": "Test2232"
}'