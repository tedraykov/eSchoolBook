import {StudentDialogData} from "./StudentDialogData";

export interface ParentData {
    schoolUserId: string;
    fullName: string;
    address: string;
    children: Array<string>;
    childrenData: Array<StudentDialogData>;
    email: string;
}