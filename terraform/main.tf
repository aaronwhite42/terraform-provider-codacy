terraform {
  required_providers {
    codacy = {
      # copy binary to C:\Users\<username>\AppData\Roaming\terraform.d\plugins
      # or this approach https://developer.hashicorp.com/terraform/cli/config/config-file#explicit-installation-method-configuration
      source  = "advocacy.dev/aaron/codacy"
      version = "0.0.1"
    }
  }
}

provider "codacy" {
  api_token    = "SET ME!"
  base_address = "https://app.codacy.com/api/v3"
}


resource "codacy_repository" "aw_test_repo" {
  repository_provider = "gh"
  full_path           = "aaronwhite42/terraform-provider-codacy"
}
