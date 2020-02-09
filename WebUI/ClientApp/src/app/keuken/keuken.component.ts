import { Component, OnInit } from "@angular/core";
import { KitchenOrdersService, KitchenOrderVm } from "../api-generated";

@Component({
  selector: "app-keuken",
  templateUrl: "./keuken.component.html",
  styleUrls: ["./keuken.component.scss"]
})
export class KeukenComponent implements OnInit {
  public bestellingen: KitchenOrderVm[];
  constructor(private service: KitchenOrdersService) {
    service.get().subscribe(response => {
      this.bestellingen = response;
      console.log(response);
    });
  }

  ngOnInit() {}
}
