Write-Host "Rozpoczynamy..."
for($i=0; $i -lt 10; $i++) {
  Write-Host "$i"
  Invoke-RestMethod "http://localhost:8080/hello/$i" -Method GET
}