import { Component, OnInit } from "@angular/core";
import {
  KitchenOrdersService,
  KeukenServedCommand,
  KeukenVm
} from "../api-generated";
import { HomeComponent } from "../home/home.component";

@Component({
  selector: "app-keuken",
  templateUrl: "./keuken.component.html",
  styleUrls: ["./keuken.component.css"]
})
export class KeukenComponent implements OnInit {
  public order: KeukenVm;
  public bestellingen: KeukenVm[];

  constructor(private service: KitchenOrdersService) {}

  ngOnInit() {
    this.service.get().subscribe(response => {
      this.bestellingen = response;
    });
  }
  async BestellingGemaakt(order: KeukenVm) {
    order.done = true;
    console.log(order.orderId);
    this.service
      .update(order.orderId, KeukenServedCommand.fromJS(this.order))
      .subscribe(
        () => {
          this.ngOnInit();
          console.log("gelukt");
          console.log(this.bestellingen);
        },
        error => console.log(error)
      );
  }
}
