# Configure the Microsoft Azure Provider
provider "azurerm" {
  features {}
  subscription_id = ""
}

# Create a resource group
resource "azurerm_resource_group" "resource_group_training" {
  name     = var.resource_group_name
  location = "East US"
}

# Create a server SQL
resource "azurerm_sql_server" "sql_server_training" {
  name                         = var.sqlserver_name
  resource_group_name          = azurerm_resource_group.resource_group_training.name
  location                     = azurerm_resource_group.resource_group_training.location
  version                      = "12.0"
  administrator_login          = var.login
  administrator_login_password = var.login_password 

  tags = {
    environment = "production"
  }
}

# Create a firewaal rule
resource "azurerm_sql_firewall_rule" "firewall_sql_server_desktop_training" {
  name                = "serveraforo255sql-firewallrule-desktop-all"
  resource_group_name = azurerm_resource_group.resource_group_training.name
  server_name         = azurerm_sql_server.sql_server_training.name
  start_ip_address    = "0.0.0.0"
  end_ip_address      = "255.255.255.255"
}

resource "azurerm_sql_firewall_rule" "firewall_sql_azure_access_server_training" {
  name                = "serveraforo255sql-firewallrule-access-to-azure"
  resource_group_name = azurerm_resource_group.resource_group_training.name
  server_name         = azurerm_sql_server.sql_server_training.name
  start_ip_address    = "0.0.0.0"
  end_ip_address      = "0.0.0.0"
}

# Create a Database SQL
resource "azurerm_sql_database" "resource_group_sql_database" {
  name                = "DB_ACCOUNT"
  resource_group_name = azurerm_resource_group.resource_group_training.name
  location            = azurerm_resource_group.resource_group_training.location
  server_name         = azurerm_sql_server.sql_server_training.name
  edition             = "Basic"
  tags = {
    environment = "production"
  }
}
