using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public abstract class Block : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public RectTransform Left, Mid, Bot;
    public GameObject Bott, Leftt;
    float upper, under;
    public GameObject[] canvass;
    public GameObject can = null;
    public class Connection
    {
        public const float kMinimumAttachRadius = 0.008f;
        public enum ConnectionType { ConnectionTypeMale, ConnectionTypeFemale, Main, Variable1, Variable2, If, Inside1, Inside2, Previous, Next };
        public Block ownerBlock;
        public ConnectionType connectionType;
        public Vector3 relativePosition;
        public Block connectedBlock;
        public BlockType acceptableBlockType;
        public Connection(Block ownerBlock, Vector3 relativePosition, ConnectionType connectionType)
        {
            this.ownerBlock = ownerBlock;
            this.relativePosition = relativePosition;
            this.connectionType = connectionType;
        }
        public float getkMinimumAttachRadius()
        {
            return kMinimumAttachRadius;
        }
        public void SetAcceptableBlockType(BlockType acceptableBlockType)
        {
            this.acceptableBlockType = acceptableBlockType;
        }

        public Block GetConnectedBlock()
        {
            return this.connectedBlock;
        }

        public Vector3 AbsolutePosition()
        {
            Vector3 parentScale = GameObject.FindWithTag("Canvas").transform.localScale;
            Vector3 parentPos = GameObject.FindWithTag("Canvas").transform.localPosition;
            float tempX1 = 0;
            if (this.connectionType == ConnectionType.Next)
            {
                if (this.ownerBlock.Inside1 != null)
                {
                    Block In1 = this.ownerBlock.Inside1;
                    if (In1.GetLength() >= 1)
                    {
                        tempX1 += In1.GetHeight();

                    }
                }
                if (this.ownerBlock.Inside2 != null)
                {
                    Block In2 = this.ownerBlock.Inside2;
                    if (In2.GetLength() >= 1)
                    {
                        tempX1 += In2.GetHeight();
                    }
                }
                this.ownerBlock.OnChangeNextDelta(new Vector3(0, -tempX1));
            }
            if (this.connectionType == ConnectionType.Inside2)
            {
                if (this.ownerBlock.Inside1 != null)
                {
                    Block In1 = this.ownerBlock.Inside1;
                    if (In1.GetLength() >= 1)
                    {
                        tempX1 += In1.GetHeight();
                    }
                }
                this.ownerBlock.OnChangeInside2Delta(new Vector3(0, -tempX1));
            }
            if (this.connectionType == ConnectionType.Next)
            {
                this.ownerBlock.under = (new Vector3(this.ownerBlock.transform.position.x, this.ownerBlock.transform.position.y) +
                    new Vector3(((this.ownerBlock.rectTransform.sizeDelta.x / 100 * this.relativePosition.x) - this.ownerBlock.rectTransform.sizeDelta.x / 2) * parentScale.x,
                        ((this.ownerBlock.rectTransform.sizeDelta.y / 100 * this.relativePosition.y) - this.ownerBlock.rectTransform.sizeDelta.y / 2) * parentScale.y - tempX1)).y;
            }
            if (this.connectionType == ConnectionType.Previous)
            {
                this.ownerBlock.upper = (new Vector3(this.ownerBlock.transform.position.x, this.ownerBlock.transform.position.y) +
                    new Vector3(((this.ownerBlock.rectTransform.sizeDelta.x / 100 * this.relativePosition.x) - this.ownerBlock.rectTransform.sizeDelta.x / 2) * parentScale.x,
                        ((this.ownerBlock.rectTransform.sizeDelta.y / 100 * this.relativePosition.y) - this.ownerBlock.rectTransform.sizeDelta.y / 2) * parentScale.y - tempX1)).y;
            }


            return new Vector3(((this.ownerBlock.rectTransform.sizeDelta.x / 100 * this.relativePosition.x) - this.ownerBlock.rectTransform.sizeDelta.x / 2) * parentScale.x + this.ownerBlock.transform.position.x,
                      ((this.ownerBlock.rectTransform.sizeDelta.y / 100 * this.relativePosition.y) - this.ownerBlock.rectTransform.sizeDelta.y / 2) * parentScale.y - tempX1 + this.ownerBlock.transform.position.y,
                      this.ownerBlock.transform.position.z);

        }
        float DistanceTo(Connection connection)
        {
            return Vector3.Distance(this.AbsolutePosition(), connection.AbsolutePosition());
        }
        public bool TryAttachWithBlock(Block block)
        {
            foreach (Connection connection in block.connections)
            {
                if (this.connectionType != connection.connectionType &&
                    (this.connectionType == Connection.ConnectionType.Previous || connection.connectionType == Connection.ConnectionType.Previous) &&
                    connection.connectedBlock == null &&
                    this.connectedBlock == null &&
                    (this.acceptableBlockType & block.GetBlockType()) != BlockType.BlockTypeNone &&
                    (connection.acceptableBlockType & ownerBlock.GetBlockType()) != BlockType.BlockTypeNone &&
                    this.DistanceTo(connection) <= kMinimumAttachRadius)
                {

                    if (this.ownerBlock.connections.IndexOf(this) == 0)
                    {
                        Vector2 delta = connection.AbsolutePosition() - this.AbsolutePosition();

                        this.ownerBlock.ApplyDelta(delta);
                    }
                    else
                    {
                        Vector2 delta = this.AbsolutePosition() - connection.AbsolutePosition();

                        block.ApplyDelta(delta);
                    }
                    Connection tempCon;
                    Block tempBlock;
                    if (connection.connectionType == Connection.ConnectionType.Previous)
                    {
                        tempCon = this;
                        tempBlock = block;
                        block.Previous = this.ownerBlock;

                    }
                    else
                    {
                        tempCon = connection;
                        tempBlock = this.ownerBlock;
                        this.ownerBlock.Previous = block;
                    }
                    // Debug.Log(tempCon.connectionType);
                    // Debug.Log(tempBlock);
                    // Debug.Log(this.Previous);
                    // Debug.Log(connection.Previous);
                    if (tempCon.connectionType == Connection.ConnectionType.Next)
                    {
                        tempCon.ownerBlock.Next = tempBlock;
                    }
                    if (tempCon.connectionType == Connection.ConnectionType.If)
                    {
                        tempCon.ownerBlock.If = tempBlock;
                    }
                    if (tempCon.connectionType == Connection.ConnectionType.Inside1)
                    {
                        tempCon.ownerBlock.Inside1 = tempBlock;
                    }
                    if (tempCon.connectionType == Connection.ConnectionType.Inside2)
                    {
                        tempCon.ownerBlock.Inside2 = tempBlock;
                    }
                    if (tempCon.connectionType == Connection.ConnectionType.Variable1)
                    {
                        tempCon.ownerBlock.Variable1 = tempBlock;
                    }
                    if (tempCon.connectionType == Connection.ConnectionType.Variable2)
                    {
                        tempCon.ownerBlock.Variable2 = tempBlock;
                    }
                    this.connectedBlock = block;
                    connection.connectedBlock = this.ownerBlock;

                    return true;
                }
            }

            return false;
        }
        public void Detach()
        {
            if (this.connectedBlock != null)
            {
                foreach (Connection connection in this.connectedBlock.connections)
                {
                    if (connection.connectedBlock != null && connection.connectedBlock.Equals(this.ownerBlock))
                    {
                        connection.connectedBlock = null;
                        break;
                    }
                }
                this.connectedBlock = null;
            }
        }
    }

    [System.Flags]
    public enum BlockType
    {
        BlockTypeNone = 0,
        BlockTypeStart = 1 << 0,
        BlockTypeInscrution = 1 << 1,
        BlockTypeLogic = 1 << 2,
        BlockTypeNumeric = 1 << 3,
        BlockTypeConditionJoint = 1 << 4
    };

    protected ArrayList connections = new ArrayList();
    protected RectTransform rectTransform;
    protected BlockType blockType;
    protected Image image;
    protected Shadow shadow;
    public Block connectedBlock, If, Inside1, Inside2, Next, Variable1, Variable2, Previous;
    public bool leaveClone = true;
    public bool isStartBlock = false, isForeverBlock = false;
    private AudioSource aSource;
    public BlockType GetBlockType()
    {
        return this.blockType;
    }

    protected abstract void CreateConnections();
    public virtual void Run() { }
    public virtual bool CheckCond() { return true; }
    public virtual double GetValue() { return 0; }
    Transform uiHelperPos;
    protected void Start()
    {
        // this.GetComponent<Button> ().onClick.AddListener (Run);
        uiHelperPos = GameObject.Find("UIHelpers").transform.GetChild(1).transform;
        canvass = GameObject.FindGameObjectsWithTag("Canvas");
        foreach (GameObject c in canvass)
        {
            if (c.GetComponent<ID>() != null)
                if (c.GetComponent<ID>().Id == "Canvas")
                {
                    can = c;
                }
        }
        aSource = gameObject.AddComponent<AudioSource>();
        this.rectTransform = gameObject.GetComponent<RectTransform>();
        this.image = gameObject.GetComponent<Image>();
        this.shadow = gameObject.GetComponent<Shadow>();
        this.shadow.enabled = false;

        this.CreateConnections();
    }

    void OnDrawGizmos()
    {

        foreach (Connection connection in this.connections)
        {
            if (connection.connectionType == Connection.ConnectionType.Previous)
            {
                Gizmos.color = Color.blue;
            }
            else
            {
                Gizmos.color = Color.red;
            }
            Gizmos.DrawSphere(connection.AbsolutePosition(), connection.getkMinimumAttachRadius());
        }
    }

    public void SetShadowActive(bool active)
    {
        this.shadow.enabled = active;
    }

    public void Detach()
    {
        Connection firstConnection = this.connections[0] as Connection;
        firstConnection.Detach();
    }
    Vector3 _Next = Vector3.zero, _Inside2 = Vector3.zero;
    public void OnChangeNextDelta(Vector3 delta)
    {
        if (_Next != delta)
        {
            if (this.Next != null) this.Next.ApplyDelta(delta - _Next);
            Vector2 oldPos = Bot.anchoredPosition;
            Bott.transform.position = Bott.transform.position + new Vector3(0, (delta.y - _Next.y));
            Left.anchoredPosition = Left.anchoredPosition + new Vector2(0, (Bot.anchoredPosition.y - oldPos.y)) / 2;
            Left.sizeDelta = Left.sizeDelta - new Vector2(0, (Bot.anchoredPosition.y - oldPos.y));
            // Bot.anchoredPosition=Bot.anchoredPosition+(delta-_Next);
            // Leftt.transform.position = Leftt.transform.position + new Vector3 (0, (delta.y - _Next.y) );
            // Leftt.transform.localScale = new Vector3(Leftt.transform.localScale.x,Leftt.transform.localScale.y + (delta.y-_Next.y));

            _Next = delta;
        }
    }
    public void OnChangeInside2Delta(Vector3 delta)
    {
        if (_Inside2 != delta)
        {
            if (this.Inside2 != null) this.Inside2.ApplyDelta(delta - _Inside2);
            Vector2 oldPos = Bot.anchoredPosition;
            Bott.transform.position = Bott.transform.position + new Vector3(0, (delta.y - _Inside2.y));
            Left.anchoredPosition = Left.anchoredPosition + new Vector2(0, (Bot.anchoredPosition.y - _Inside2.y)) / 2;
            Left.sizeDelta = Left.sizeDelta - new Vector2(0, (Bot.anchoredPosition.y - oldPos.y));
            _Inside2 = delta;
        }
    }
    public void ApplyDelta(Vector3 delta)
    {
        ArrayList descendingBlocks = this.DescendingBlocks();

        foreach (Block block in descendingBlocks)
        {
            block.transform.position = block.transform.position + delta;
        }
    }
    public int GetLength()
    {
        if (Next != null)
            return 1 + Next.GetLength();
        else
            return 1;
    }
    public float GetHeight()
    {
        if (Next != null)
            return (this.upper - this.under) + Next.GetHeight();
        else
            return (this.upper - this.under);
    }
    public bool TryAttachInSomeConnectionWithBlock(Block block)
    {
        if (this.Equals(block))
        {
            return false;
        }

        ArrayList descendingBlocks = this.DescendingBlocks();

        foreach (Block aBlock in descendingBlocks)
        {
            foreach (Connection conection in aBlock.connections)
            {
                if (conection.TryAttachWithBlock(block))
                {
                    return true;
                }
            }
        }
        return false;
    }
    private void Update()
    {
        RectTransform getRect = this.gameObject.GetComponent<RectTransform>();
        getRect.anchoredPosition3D = new Vector3(getRect.anchoredPosition3D.x, getRect.anchoredPosition3D.y, 0);
        foreach (Connection connection in this.connections)
        {
            connection.AbsolutePosition();
        }
    }
    public ArrayList DescendingBlocks()
    {
        ArrayList arrayList = new ArrayList();
        arrayList.Add(this);

        for (int i = 1; i < this.connections.Count; ++i)
        {
            Connection connection = this.connections[i] as Connection;

            if (connection.GetConnectedBlock() != null && connection.GetConnectedBlock().Equals(this) == false)
            {
                ArrayList descendingBlocks = connection.GetConnectedBlock().DescendingBlocks();
                foreach (Block block in descendingBlocks)
                {
                    arrayList.Add(block);
                }
            }
        }

        return arrayList;
    }

    #region Drag
    void Disconect(Block child)
    {
        if (If == child)
        {
            If = null;
        }
        if (Inside1 == child)
        {
            Inside1 = null;
        }
        if (Inside2 == child)
        {
            Inside2 = null;
        }
        if (Variable1 == child)
        {
            Variable1 = null;
        }
        if (Variable2 == child)
        {
            Variable2 = null;
        }
        if (Next == child)
        {
            Next = null;
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        /*aSource.clip = GameObject.Find ("SoundBox").GetComponent<SoundBox> ().DragSound;
		if (!aSource.isPlaying) {
			aSource.Play ();
		}*/
        if (this.Previous != null) this.Previous.Disconect(this);
        this.Previous = null;
        if (this.leaveClone)
        {
            GameObject go = Instantiate(this.gameObject);

            go.GetComponent<Block>().leaveClone = true;

            go.transform.SetParent(this.transform.parent, false);
            go.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

            this.transform.SetParent((can ?? GameObject.FindWithTag("Canvas")).transform, false);
            this.leaveClone = false;

            go.GetComponent<RectTransform>().anchoredPosition = this.rectTransform.anchoredPosition;
            go.GetComponent<RectTransform>().sizeDelta = this.rectTransform.sizeDelta;
            go.GetComponent<RectTransform>().anchorMin = this.rectTransform.anchorMin;
            go.GetComponent<RectTransform>().anchorMax = this.rectTransform.anchorMax;
            this.GetComponent<RectTransform>().position = go.GetComponent<RectTransform>().position;
        }

        // Desconecta do bloco acima

        this.Detach();

        // Deixa todos os blocos descendetes no topo da telas
        ArrayList descendingBlocks = this.DescendingBlocks();

        foreach (Block block in descendingBlocks)
        {
            Vector3 previousPosition = block.transform.position;


            block.transform.SetParent((can ?? GameObject.FindWithTag("Canvas")).transform, false);
            block.transform.position = previousPosition;
            block.transform.SetSiblingIndex(block.transform.parent.childCount - 1);
            block.SetShadowActive(true);
        }

    }

    Vector3 lastMousePosition = Vector3.zero;
    public void OnDrag(PointerEventData eventData)
    {
        // Aplica delta em função do drag
        if (lastMousePosition == Vector3.zero)
        {
            lastMousePosition = uiHelperPos.position;
        }
        else
        {
            this.ApplyDelta(uiHelperPos.position - lastMousePosition);

            lastMousePosition = uiHelperPos.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //aSource.clip = GameObject.Find ("SoundBox").GetComponent<SoundBox> ().DropSound;
        //if (!aSource.isPlaying) {
        //	aSource.Play ();
        //}
        GameObject[] AllC = GameObject.FindGameObjectsWithTag("CodeContent");
        GameObject codeContentGO = GameObject.FindWithTag("CodeContent");
        foreach (GameObject c in AllC)
        {
            if (c.GetComponent<CodeContent>().isCurrent)
            {
                codeContentGO = c;
            }
        }
        // if (transform.parent.gameObject.Equals (codeContentGO) == false) {
        RectTransform rect = codeContentGO.GetComponent<RectTransform>();
        Vector2 mousePos = new Vector2(uiHelperPos.position.x, uiHelperPos.position.y);

        if (RectTransformUtility.RectangleContainsScreenPoint(rect, mousePos))
        {
            GameObject[] allChildren = GameObject.FindGameObjectsWithTag("PackContent");
            GameObject match = null;
            foreach (GameObject child in allChildren)
            {
                if (RectTransformUtility.RectangleContainsScreenPoint(child.GetComponent<RectTransform>(), mousePos) && child.transform.parent.transform.parent.GetComponent<CanvasGroup>().alpha == 1) match = child;
            }
            if (match != null)
            {
                ArrayList des = this.DescendingBlocks();
                foreach (Block block in des)
                {
                    Vector3 previousPosition = block.transform.position;
                    block.transform.SetParent(match.transform, false);
                    block.transform.position = previousPosition;
                }

            }
            else
            {
                ArrayList des = this.DescendingBlocks();
                foreach (Block block in des)
                {
                    Vector3 previousPosition = block.transform.position;
                    block.transform.SetParent(codeContentGO.transform, false);
                    block.transform.position = previousPosition;
                }
            }
        }
        else
        {
            ArrayList des = this.DescendingBlocks();
            foreach (Block block in des)
            {
                Destroy(block.gameObject);
            }

            return;
            // }
        }

        lastMousePosition = Vector3.zero;

        ArrayList descendingBlocks = this.DescendingBlocks();
        foreach (Block block in descendingBlocks)
        {
            block.SetShadowActive(false);
        }

        // Tenta conectar com algum bloco
        GameObject[] GOs = GameObject.FindGameObjectsWithTag("Block");
        // Debug.Log (GOs.Length);
        foreach (GameObject GO in GOs)
        {
            Block block = GO.GetComponent<Block>() as Block;
            // Debug.Log (GO);
            if (this.TryAttachInSomeConnectionWithBlock(block))
            {
                break;
            }
        }
    }

    #endregion

}