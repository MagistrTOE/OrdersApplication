import React from "react";

export interface IButtonProps {
    children: React.ReactNode;
    buttonOnClick?: (e: React.MouseEvent<HTMLButtonElement>) => void;
    className?: string;
    type?: 'submit' | 'reset' | 'button';
}

const Mybutton: React.FC<IButtonProps> = (props) => {
    return (
        <button 
            className={props.className}
            type={props.type}
            onClick={props.buttonOnClick}>
            {props.children}
        </button>
    )
}

export default Mybutton;