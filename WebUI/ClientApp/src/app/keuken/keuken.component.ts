import { Component, OnInit } from "@angular/core";
import {
  KitchenOrdersService,
  KeukenServedCommand,
  KeukenVm
} from "../api-generated";
import { NavigationEnd, Route } from "@angular/router";

@Component({
  selector: "app-keuken",
  templateUrl: "./keuken.component.html",
  styleUrls: ["./keuken.component.css"]
})
export class KeukenComponent implements OnInit {
  public order: KeukenVm;
  public bestellingen: KeukenVm[];
  mySubscription: any;
  timeLeft: number = 5;
  interval;

  constructor(private service: KitchenOrdersService) {}

  ngOnInit() {
    this.loadData();
  }
  startTimer() {}
  async BestellingGemaakt(order: KeukenVm) {
    order.done = true;
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
  loadData() {
    this.service.get().subscribe(response => {
      this.bestellingen = response;
    });
  }
}
