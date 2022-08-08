import React from "react";
import classes from './Myinput.module.css'

interface IInputProps {
    type?: React.HTMLInputTypeAttribute;
    asp?: string;
    max?: number;
    min?: number;
    maxLength?: number;
    value?: string;
    title?: string;
    placeholder?: string;
    onChange?: (event: React.ChangeEvent<HTMLInputElement>) => void; 
}

const Myinput: React.FC<IInputProps> = (props) => {

    return(
        <div>
        <input             
            className={classes.Input}
            type={props.type}       
            asp={props.asp}
            max={props.max}
            min={props.min}
            maxLength={props.maxLength}
            title={props.title}
            value={props.value}
            placeholder={props.placeholder}
            onChange={props.onChange}
            {...props} />
        </div>
    )
}

export default Myinput;