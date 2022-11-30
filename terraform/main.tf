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


resource "codacy_resource" "example" {
  some_value = "This is a test resource"
  provider   = codacy
}
