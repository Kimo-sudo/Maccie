import { Component, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import {
  EmployeeService,
  Employee,
  ProductenService,
  Product
} from "../api-generated";

@Component({
  selector: "app-fetch-data",
  templateUrl: "./fetch-data.component.html"
})
export class FetchDataComponent {
  public werknemers: Employee[] = [];
  public producten: Product[] = [];

  constructor(
    private service: EmployeeService,
    private productService: ProductenService
  ) {
    service.getAllEmployees().subscribe(response => {
      this.werknemers = response;
      console.log(response);
    });
    productService.getAllProducts().subscribe(response => {
      this.producten = response;
      console.log(response);
    });
  }
}
