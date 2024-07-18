# Day 71

## Topics covered

- ARM Template
- Azure DevOps

## Work Done

### Question 1

Create ARM Template for creating a SQL server

The template for this can be found [here](./sqlservertemplate.json)

**Azure CLI**
```
az deployment group create --resource-group <your-resource-group> --template-file <path-to-your-template-file> --parameters sqlServerName=<your-sql-server-name> adminUsername=<your-admin-username> adminPassword=<your-admin-password>
```


### Question 2

Create an ARM Template for creating a Azure vault and add the connection string of SQL in the secret

The template for this can be found [here](./azurekeyvaulttemplateone.json)

**Azure CLI**
```
az deployment group create --resource-group <your-resource-group> --template-file <path-to-your-template-file> --parameters vaultName=<your-key-vault-name> sqlConnectionString=<your-sql-connection-string>
```