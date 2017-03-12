$zip = "c:\Program Files\7-Zip\7z.exe"

& dotnet publish ./src/MongoMessage -c Release -o ./tmp/mongomessage
& $zip a ./dockerfiles/app/mongomessage.7z ./tmp/mongomessage
& docker build -f ./dockerfiles/Dockerfile -t fpommerening/spartakiade2017-docker:mongomessage ./dockerfiles/
