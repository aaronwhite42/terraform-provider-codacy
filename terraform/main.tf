terraform {
  required_providers {
    codacy = {
      # copy binary to C:\Users\<username>\AppData\Roaming\terraform.d\plugins
      # or use this approach https://developer.hashicorp.com/terraform/cli/config/config-file#explicit-installation-method-configuration
      source  = "advocacy.dev/aaron/codacy"
      version = "0.0.1"
    }
  }
}

provider "codacy" {
  api_token = "SET ME!"
}


resource "codacy_repository" "aw_test_repo" {
  owner = "aaronwhite42"
  name  = "terraform-provider-codacy"
}
