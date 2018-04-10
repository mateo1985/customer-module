curl -X POST \
  http://localhost:5000/Customer \
  -H 'content-type: application/json' \
  -d '{
	"Id": "2",
	"Name": "SomeName",
	"Surrname": "CHANGED",
	"Telephone": "+481231231",
	"Address": "Test address222"
}'