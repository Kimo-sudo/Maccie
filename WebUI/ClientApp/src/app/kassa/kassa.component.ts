import { Component, OnInit } from "@angular/core";
import {
  BestellingenService,
  ProductenService,
  Order,
  AddBestellingCommand,
  AddBurgerDto,
  Product
} from "../api-generated";
import { KeukenComponent } from "../keuken/keuken.component";
import { Router, RouterModule, Params } from "@angular/router";

@Component({
  selector: "app-kassa",
  templateUrl: "./kassa.component.html",
  styleUrls: ["./kassa.component.css"]
})
export class KassaComponent implements OnInit {
  public AlleBestellingen: Order[];
  public NieuweBestelling: AddBurgerDto[] = [];
  public alleProducten: Product[] = [];

  constructor(
    private orderService: BestellingenService,
    private productService: ProductenService
  ) {}
  ngOnInit() {
    this.loadProduct();
  }
  addProduct(id: any): void {
    var x = new AddBurgerDto();
    x.amount = 1;
    x.productId = this.alleProducten[id].id;
    x.productName = this.alleProducten[id].productName;
    if (this.NieuweBestelling.some(z => z.productId == x.productId)) {
      this.NieuweBestelling.filter(y => y.productId == x.productId).forEach(
        z => z.amount++
      );
    } else {
      this.NieuweBestelling.push(x);
    }
    console.log(this.NieuweBestelling);
  }

  confirmOrder(): void {
    this.orderService
      .post(<AddBestellingCommand>{
        producten: this.NieuweBestelling
      })
      .subscribe();
    this.NieuweBestelling = [];
  }

  loadProduct(): void {
    this.productService.getAllProducts().subscribe(response => {
      this.alleProducten = response;
      console.log(this.alleProducten);
    });
  }
}
