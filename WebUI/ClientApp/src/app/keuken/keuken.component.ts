import { Component, OnInit } from "@angular/core";
import {
  KitchenOrdersService,
  KeukenServedCommand,
  KitchenVm
} from "../api-generated";

@Component({
  selector: "app-keuken",
  templateUrl: "./keuken.component.html",
  styleUrls: ["./keuken.component.css"]
})
export class KeukenComponent implements OnInit {
  public order: KitchenVm;
  public bestellingen: KitchenVm[];

  constructor(private service: KitchenOrdersService) {}

  ngOnInit() {
    this.service.get().subscribe(response => {
      this.bestellingen = response;
      console.log(response);
    });
  }
  async BestellingGemaakt(order: KitchenVm) {
    order.done = true;
    console.log(order.orderId);
    this.service
      .update(order.orderId, KeukenServedCommand.fromJS(this.order))
      .subscribe(
        () => {
          this.ngOnInit();
          console.log("gelukt");
        },
        error => console.log(error)
      );
  }
}
