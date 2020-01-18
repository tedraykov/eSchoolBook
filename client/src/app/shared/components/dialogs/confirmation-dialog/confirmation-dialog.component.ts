import {Component, Input, OnInit} from '@angular/core';
import {NbDialogRef} from "@nebular/theme";

@Component({
  selector: 'app-confirmation-dialog',
  templateUrl: './confirmation-dialog.component.html',
  styleUrls: ['./confirmation-dialog.component.scss']
})
export class ConfirmationDialogComponent implements OnInit {
  message: string;
  
  
  constructor(
      protected dialogRef: NbDialogRef<ConfirmationDialogComponent>
  ) { }

  ngOnInit() {
  }
  
  approve(): boolean {
    this.dialogRef.close(true);
    return true;
  }

  close(): boolean{
    this.dialogRef.close(false);
    return false;
  }

}
