curl -X PUT \
  http://localhost:5000/Customer \
  -H 'content-type: application/json' \
  -d '{
	"Name": "ExampleName",
	"Surrname": "ExampleSurrname",
	"Telephone": "+481231231",
	"Address": "Test2232"
}'