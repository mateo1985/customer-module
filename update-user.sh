curl -X POST \
  http://localhost:5000/Customer \
  -H 'content-type: application/json' \
  -d '{
	"Id": "50002",
	"Name": "SomeName",
	"Surrname": "OtherSurrname",
	"Telephone": "+481231231",
	"Address": "Test address222"
}'